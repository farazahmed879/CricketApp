import { Component, Injector } from '@angular/core';
import { finalize } from 'rxjs/operators';
import { BsModalService, BsModalRef } from 'ngx-bootstrap/modal';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import {
    PagedListingComponentBase,
    PagedRequestDto
} from 'shared/paged-listing-component-base';
import {
    TeamServiceProxy,
    TeamDto,
    TeamDtoPagedResultDto
} from '@shared/service-proxies/service-proxies';
import { CreateTeamDialogComponent } from './create-team/create-team-dialog.component';
import { EditTeamDialogComponent } from './edit-team/edit-team-dialog.component';

class PagedTeamRequestDto extends PagedRequestDto {
    keyword: string;
}

@Component({
    templateUrl: './team.component.html',
    animations: [appModuleAnimation()],
    styles: ['./team.component.less']
})
export class TeamComponent extends PagedListingComponentBase<TeamDto> {
    teams: TeamDto[] = [];
    keyword = '';
    advancedFiltersVisible = false;

    constructor(
        injector: Injector,
        private _teamService: TeamServiceProxy,
        private _modalService: BsModalService
    ) {
        super(injector);
    }

    list(
        request: PagedRequestDto,
        pageNumber: number,
        finishedCallback: Function
    ): void {

        // request.keyword = this.keyword;
        this._teamService
            .getPaginatedAll(undefined, this.appSession.tenantId, request.skipCount, request.maxResultCount)
            .pipe(
                finalize(() => {
                    finishedCallback();
                })
            )
            .subscribe((result: TeamDtoPagedResultDto) => {
                this.teams = result.items;
                this.totalItems = result.totalCount;
                this.showPaging(result, pageNumber);
            });
    }

    delete(team: TeamDto): void {
        abp.message.confirm(
            this.l('TeamDeleteWarningMessage', team.name),
            undefined,
            (result: boolean) => {
                if (result) {
                    this._teamService
                        .delete(team.id)
                        .pipe(
                            finalize(() => {
                                abp.notify.success(this.l('SuccessfullyDeleted'));
                                this.refresh();
                            })
                        )
                        .subscribe(() => { });
                }
            }
        );
    }

    createTeam(): void {
        this.showCreateOrEditDialog();
    }

    edit(team: TeamDto): void {
        this.showCreateOrEditDialog(team.id);
    }

    showCreateOrEditDialog(id?: number): void {
        let createOrEditTeamDialog: BsModalRef;
        if (id === undefined || id <= 0) {
            createOrEditTeamDialog = this._modalService.show(CreateTeamDialogComponent,
                {
                    class: 'modal-lg',
                });
        } else {
            createOrEditTeamDialog = this._modalService.show(EditTeamDialogComponent,
                {
                    class: 'modal-lg',
                    initialState: {
                      id: id,
                    },
                });
        }

        createOrEditTeamDialog.content.onSave.subscribe(() => {
            this.refresh();
          });
    }
}
