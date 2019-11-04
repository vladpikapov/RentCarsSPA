import { Component, OnInit } from '@angular/core';
import { DriversService } from '../shared/drivers.service';

@Component({
  selector: 'app-drivers',
  templateUrl: './drivers.component.html',
  styleUrls: ['./drivers.component.css']
})
export class DriversComponent implements OnInit {

  constructor(private driversService: DriversService) { }

  ngOnInit() {
    this.driversService.fetchDrivers();
    this.driversService.drivers
    }
  }


