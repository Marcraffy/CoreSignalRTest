import { ViewChild, Injector, Output, EventEmitter, ElementRef, OnInit, Component } from '@angular/core';
import { ModalDirective } from 'ngx-bootstrap';
import { UserServiceProxy, DataDto, RoleDto, DataServiceProxy } from '@shared/service-proxies/service-proxies';
import { AppComponentBase } from '@shared/app-component-base';
import { finalize } from 'rxjs/operators';

@Component({
  selector: 'create-data-modal',
  templateUrl: './create-data.component.html'
})
export class CreateDataComponent extends AppComponentBase{

    @ViewChild('createDataModal') modal: ModalDirective;
    @ViewChild('modalContent') modalContent: ElementRef;

    @Output() modalSave: EventEmitter<any> = new EventEmitter<any>();

    active: boolean = false;
    saving: boolean = false;
    data: DataDto = null;

    constructor(
        injector: Injector,
        private dataService: DataServiceProxy,
    ) {
        super(injector);
    }

    show(): void {
        this.active = true;
        this.modal.show();
        this.data = new DataDto();
    }

    onShown(): void {
        $.AdminBSB.input.activate($(this.modalContent.nativeElement));
    }

    save(): void {
        this.saving = true;
        this.dataService.create(this.data)
            .pipe(finalize(() => { 
                this.saving = false; 
            }))
            .subscribe(() => {
                this.notify.info(this.l('SavedSuccessfully'));
                this.close();
                this.modalSave.emit(null);
            });
    }

    close(): void {
        this.active = false;
        this.modal.hide();
    }
}
