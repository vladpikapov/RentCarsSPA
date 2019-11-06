import {Injectable} from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {OrdersAddComponent} from '../orders/orders-add/orders-add.component';
import {FormGroup, NgForm} from '@angular/forms';
import {Observable} from 'rxjs';

export interface Orders {
  Id: number;
  StartDate: Date;
  EndDate: Date;
  Comment: string;
  DriverLicense: string;
  CarId: string;
}

@Injectable ({providedIn: 'root'})
export class OrdersService {

  public ordersUrl = 'http://localhost:62131/api/orders';
  public orders: Orders[];
  public order: Orders;
  countSort = 0;
  constructor(private http: HttpClient) {
    this.getOrders();
  }

  getOrders() {
    this.http.get(this.ordersUrl).
    toPromise().then(res => this.orders = res as Orders[]);
  }

  postOrders(orderComp: FormGroup) {
    return this.http.post(this.ordersUrl, orderComp);
  }

  deleteOrder(url: string): Observable<{}> {
    if (window.confirm('Are you sure, you want to delete ?')) {
      return this.http.delete(url);
    }
  }

  putOrder(Id: number, order: Orders) {
    return this.http.put(this.ordersUrl + '/' + Id, order);
  }

  getOrdersByStartDate(startDate: string) {
    this.http.get(this.ordersUrl + '/date/startDate/' +  startDate).toPromise().then(res => this.orders = res as Orders[]);
  }

  getOrdersByDriverName(name: string) {
    this.http.get(this.ordersUrl + '/byDriver/' +  name).toPromise().then(res => this.orders = res as Orders[]);
  }

  getOrdersByEndDate(endDate: string) {
    this.http.get(this.ordersUrl + '/date/endDate/' +  endDate).toPromise().then(res => this.orders = res as Orders[]);
  }

  getOrdersByCarModel(model: string) {
    this.http.get(this.ordersUrl + '/cars/model/' + model).toPromise().then(res => this.orders = res as Orders[]);
  }

  getOrdersByCarMark(mark: string) {
    this.http.get(this.ordersUrl + '/cars/mark/' + mark).toPromise().then(res => this.orders = res as Orders[]);
  }

  SortOrdersStartDateAsc(orders: Orders[]) {
    this.orders = orders.sort((a, b) => {
      if (a.StartDate > b.StartDate) {
        return 1;
      }
      if (a.StartDate < b.StartDate) {
        return -1;
      }
      return 0;
    });
  }

  SortOrdersStartDateDesc(orders: Orders[]) {
    this.orders = orders.sort((a, b) => {
      if (a.StartDate > b.StartDate) {
        return -1;
      }
      if (a.StartDate < b.StartDate) {
        return 1;
      }
      return 0;
    });
  }

  SortOrdersByStartDate(orders: Orders[]) {
    if (this.countSort === 0) {

      this.SortOrdersStartDateAsc(orders);
    }
    console.log(this.orders);
    if (this.countSort === 1) {
      this.SortOrdersStartDateDesc(orders);
    }
    if (this.countSort === 2) {
      this.getOrders();
      this.countSort = 0;
    } else {
      this.countSort++;
    }
  }

  SortOrdersEndDateAsc(orders: Orders[]) {
    this.orders = orders.sort((a, b) => {
      if (a.EndDate > b.EndDate) {
        return 1;
      }
      if (a.EndDate < b.EndDate) {
        return -1;
      }
      return 0;
    });
  }

  SortOrdersEndDateDesc(orders: Orders[]) {
    this.orders = orders.sort((a, b) => {
      if (a.EndDate > b.EndDate) {
        return -1;
      }
      if (a.EndDate < b.EndDate) {
        return 1;
      }
      return 0;
    });
  }

  SortOrdersByEndDate(orders: Orders[]) {
    if (this.countSort === 0) {

      this.SortOrdersStartDateAsc(orders);
    }
    console.log(this.orders);
    if (this.countSort === 1) {
      this.SortOrdersStartDateDesc(orders);
    }
    if (this.countSort === 2) {
      this.getOrders();
      this.countSort = 0;
    } else {
      this.countSort++;
    }
  }
}
