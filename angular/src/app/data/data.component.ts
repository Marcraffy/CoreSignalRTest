import { Component, OnInit } from '@angular/core';
import { HubConnection, HubConnectionBuilder, LogLevel } from "@aspnet/signalr";

@Component({
  selector: 'app-data',
  templateUrl: './data.component.html',
  styleUrls: ['./data.component.css']
})
export class DataComponent implements OnInit {

  syncHub: HubConnection;
  constructor() { }

  ngOnInit() {
    abp.log.debug(`Status: ${abp.signalr.autoConnect}`);

    this.syncHub = new HubConnectionBuilder()
      .withUrl("/signalr")
      .build();

    this.syncHub.on("connected", result => {
      abp.log.debug("Sync!");
      debugger;
    });
    this.syncHub.on("signalr.connected", result => {
      abp.log.debug("Sync!");
      debugger;
    });
    this.syncHub.on("syncHub.connected", result => {
      abp.log.debug("Sync!");
      debugger;
    });
    this.syncHub.on("SyncHub.connected", result => {
      abp.log.debug("Sync!");
      debugger;
    });
    this.syncHub.on(".connected", result => {
      abp.log.debug("Sync!");
      debugger;
    });
  }
}
