import { Component, OnInit } from '@angular/core';
import {OrdersService} from '../../shared/orders.service';
import {OrdersListComponent} from '../orders-list/orders-list.component';

@Component({
  selector: 'app-orders-filter',
  templateUrl: './orders-filter.component.html',
  styleUrls: ['./orders-filter.component.css']
})
export class OrdersFilterComponent implements OnInit {
  SelectParameter;
  constructor(private orderService: OrdersService) {
  }

  ngOnInit() {
  }

  SearchBySelectParameter(element: string, url: string) {
    this.orderService.getOrdersBySelectParameter(element, url);
  }

  ResetSearchSettings() {
    this.orderService.getOrders();
    this.SelectParameter = null;
  }

  SortBy(value: any) {
    if (value === 'start') {
      this.orderService.SortOrdersByStartDate(this.orderService.orders);
    } if (value === 'end') {
      this.orderService.SortOrdersByEndDate(this.orderService.orders);
    }
  }
}
