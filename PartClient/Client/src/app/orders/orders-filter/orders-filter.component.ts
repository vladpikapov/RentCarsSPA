import { Component, OnInit } from '@angular/core';
import {OrdersService} from '../../shared/orders.service';
import {OrdersListComponent} from '../orders-list/orders-list.component';

@Component({
  selector: 'app-orders-filter',
  templateUrl: './orders-filter.component.html',
  styleUrls: ['./orders-filter.component.css']
})
export class OrdersFilterComponent implements OnInit {
  CarMark;
  CarModel;
  DriverName;
  StartDateSearch;
  EndDateSearch;
  constructor(private orderService: OrdersService) {
  }

  ngOnInit() {
  }

  SearchByCarMark() {
   this.orderService.getOrdersByCarMark(this.CarMark);
  }

  SearchByCarModel() {
    this.orderService.getOrdersByCarModel(this.CarModel);
  }

  SearchByDriverName() {
    this.orderService.getOrdersByDriverName(this.DriverName);
  }

  SearchByEndDate() {
    this.orderService.getOrdersByEndDate(this.EndDateSearch);
  }

  SearchByStartDate() {
    this.orderService.getOrdersByStartDate(this.StartDateSearch);
  }

  ResetSearchSettings() {
    this.orderService.getOrders();
    this.CarMark = null;
    this.CarModel = null;
    this.DriverName = null;
    this.StartDateSearch = null;
    this.EndDateSearch = null;
  }

  SortBy(value: any) {
    if (value === 'start') {
      this.orderService.SortOrdersByStartDate(this.orderService.orders);
    } else {
      this.orderService.SortOrdersByEndDate(this.orderService.orders);
    }
  }
}
