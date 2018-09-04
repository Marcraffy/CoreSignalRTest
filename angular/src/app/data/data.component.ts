import { Component, OnInit } from '@angular/core';
import { HubConnection } from "@aspnet/signalr";
import { DataDto } from '@shared/service-proxies/service-proxies';

@Component({
  selector: 'app-data',
  templateUrl: './data.component.html',
  styleUrls: ['./data.component.css']
})
export class DataComponent implements OnInit {

  syncHub: HubConnection;
  constructor() { }

  ngOnInit() {
    abp.event.on("abp.signalr.connected", () => {
      this.syncHub = abp.signalr.hubs.common;
      this.syncHub.on(DataDto.name, () =>{
        debugger;
      });
    })
  }
}
