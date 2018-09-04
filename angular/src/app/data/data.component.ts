import { Component, Injector, OnInit, ViewChild } from '@angular/core';
import { HubConnection, HubConnectionBuilder, LogLevel } from "@aspnet/signalr";
import { PagedRequestDto, PagedListingComponentBase } from '@shared/paged-listing-component-base';
import { DataDto, DataServiceProxy, PagedResultDtoOfDataDto } from '@shared/service-proxies/service-proxies';
import { finalize } from 'rxjs/operators';
import { AppComponentBase } from '@shared/app-component-base';
import { CreateDataComponent } from '@app/data/create-data/create-data.component';
import { request } from 'http';

@Component({
  selector: 'app-data',
  templateUrl: './data.component.html',
  styleUrls: ['./data.component.css']
})
export class DataComponent extends PagedListingComponentBase<DataDto> implements OnInit {

  @ViewChild('createDataModal') createDataModal: CreateDataComponent;

  active: boolean = false;
  data: DataDto[] = [];
  syncHub: HubConnection;

  constructor(
    injector: Injector,
    private dataService: DataServiceProxy
  ) {
    super(injector);
  }

  ngOnInit() {
    abp.event.on("abp.signalr.connected", () => {
      this.syncHub = abp.signalr.hubs.common;
      this.syncHub.on(DataDto.name, () => {
        //debugger;
        this.refresh();
      });
    })
  }

  protected list(request: PagedRequestDto, pageNumber: number, finishedCallback: Function): void {
    this.dataService.getAll('', request.skipCount, request.maxResultCount)
      .pipe(finalize(() => {
        finishedCallback()
      }))
      .subscribe((result: PagedResultDtoOfDataDto) => {
        this.data = result.items;
        this.showPaging(result, pageNumber);
      });
  }

  protected delete(data: DataDto): void {
    abp.message.confirm(
      "Delete data '" + data.id + "'?",
      (result: boolean) => {
        if (result) {
          this.dataService.delete(data.id)
            .subscribe(() => {
              abp.notify.info("Deleted Data: " + data.id);
              this.refresh();
            });
        }
      }
    );
  }

  // Show Modals
  createUser(): void {
    this.createDataModal.show();
  }
}
