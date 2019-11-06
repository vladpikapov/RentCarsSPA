import { Component, OnInit } from '@angular/core';
import {OrdersService} from '../shared/orders.service';
import {OrdersListComponent} from './orders-list/orders-list.component';

@Component({
  selector: 'app-orders',
  templateUrl: './orders.component.html',
  styleUrls: ['./orders.component.css']
})
export class OrdersComponent implements OnInit {

  constructor(private ordersService: OrdersService) {
    ordersService.getOrders();
  }

  ngOnInit() {
  }

}
