import { Component, OnInit } from '@angular/core';
import { CarsService } from '../shared/cars.service';

@Component({
  selector: 'app-cars',
  templateUrl: './cars.component.html',
  styleUrls: ['./cars.component.css']
})
export class CarsComponent implements OnInit {

  constructor(private carsService:CarsService) { }

  ngOnInit() {
    this.carsService.getCars();
  }

}
