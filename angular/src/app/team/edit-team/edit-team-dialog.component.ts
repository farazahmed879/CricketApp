import { Component, Injector, OnInit, Inject, Optional } from '@angular/core';
import { BsModalRef } from 'ngx-bootstrap/modal';
import { finalize } from 'rxjs/operators';
import { AppComponentBase } from '@shared/app-component-base';
import {
  TeamDto, TeamServiceProxy
} from '@shared/service-proxies/service-proxies';

@Component({
  templateUrl: 'edit-team-dialog.component.html',
  styles: ['./edit-team-dialog.component.less'
  ]
})
export class EditTeamDialogComponent extends AppComponentBase
  implements OnInit {
  saving = false;
  team: TeamDto = new TeamDto();
  id: number;

  constructor(
    injector: Injector,
    public _teamService: TeamServiceProxy,
    public bsModalRef: BsModalRef
  ) {
    super(injector);
  }

  ngOnInit(): void {
    debugger;
    this._teamService.getById(this.id).subscribe((result: TeamDto) => {
      this.team = result;
    });
  }

  save(): void {
    this.saving = true;
    this.team.tenantId = this.appSession.tenantId;
    debugger;
    this._teamService
      .createOrEdit(this.team)
      .pipe(
        finalize(() => {
          this.saving = false;
        })
      )
      .subscribe(() => {
        this.notify.info(this.l('SavedSuccessfully'));
        this.close(true);
      });
  }

  close(result: any): void {
    this.bsModalRef.hide();
  }
}
