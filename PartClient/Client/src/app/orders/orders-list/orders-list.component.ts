import { Component, OnInit } from '@angular/core';
import {OrdersService, Orders} from '../../shared/orders.service';
import {Sort} from '@angular/material';
import {Cars, CarsService} from '../../shared/cars.service';
import {Drivers, DriversService} from '../../shared/drivers.service';

@Component({
  selector: 'app-orders-list',
  templateUrl: './orders-list.component.html',
  styleUrls: ['./orders-list.component.css']
})
export class OrdersListComponent implements OnInit {
  EditRowID: any = null;
  display = 'none';

  constructor(private orderService: OrdersService) {
  }

  ngOnInit() {
  }
  CatchID(Id: number) {
    const url = 'http://localhost:62131/api/orders/' + Id;
   this.orderService.deleteOrder(url).subscribe(data => {
     this.orderService.getOrders();
   });
  }

  EditOrder(order: Orders) {
    if (this.EditRowID === order.Id) {
      this.EditRowID = null;
      this.orderService.getOrders();
    } else {
      this.EditRowID = order.Id;
    }
  }

  UpdateOrder(Id: number, order: Orders) {
    this.orderService.putOrder(Id, order).subscribe(res => {
        console.log('Submitted successfully');
        this.EditRowID = null;
        this.orderService.getOrders();
      },
      err => {
        console.log(err);
      });
  }


  SortData(sort: Sort) {
    this.orderService.orders.sort();
  }

  onCloseHandled() {
    this.display = 'none';
  }
  openModal(order: Orders) {

    this.display = 'block';
  }
}
