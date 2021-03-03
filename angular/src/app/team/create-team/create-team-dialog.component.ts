import {
  Component,
  Injector,
  OnInit,
  Output,
  EventEmitter
} from '@angular/core';
import { BsModalRef } from 'ngx-bootstrap/modal';
import { finalize } from 'rxjs/operators';
import {
  TeamServiceProxy,
  CreateTeamDto,
} from '@shared/service-proxies/service-proxies';
import { AppComponentBase } from '@shared/app-component-base';

@Component({
  templateUrl: 'create-team-dialog.component.html',
  styles: ['./create-team-dialog.component.less'
  ]
})
export class CreateTeamDialogComponent extends AppComponentBase
  implements OnInit {
  saving = false;
  team: CreateTeamDto = new CreateTeamDto();

  constructor(
    injector: Injector,
    public _teamService: TeamServiceProxy,
    public bsModalRef: BsModalRef
  ) {
    super(injector);
  }

  ngOnInit(): void {
  }

  save(): void {
    this.saving = true;
    this.team.tenantId = this.appSession.tenantId;
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
