import { Component, OnInit } from '@angular/core';
import { Connection } from '../../../node_modules/@angular/http';

@Component({
  selector: 'app-data',
  templateUrl: './data.component.html',
  styleUrls: ['./data.component.css']
})
export class DataComponent implements OnInit {

  syncHub: any;
  constructor() { }

  ngOnInit() {
    abp.log.debug(`Status: ${abp.signalr.autoConnect}`);
    debugger;

    abp.event.on("SyncHub.connected", () => {
      abp.log.debug("Connection acknowledged");
    });
  }
}
