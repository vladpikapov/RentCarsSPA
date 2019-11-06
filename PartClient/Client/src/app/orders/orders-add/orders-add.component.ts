import { Component, OnInit } from '@angular/core';
import {Orders, OrdersService} from '../../shared/orders.service';
import {FormGroup, NgForm, FormBuilder} from '@angular/forms';


// @ts-ignore
@Component({
  selector: 'app-orders-add',
  templateUrl: './orders-add.component.html',
  styleUrls: ['./orders-add.component.css']
})
export class OrdersAddComponent implements OnInit {
  addForm;
  constructor(private ordersService: OrdersService, private  formBuilder: FormBuilder) { }
  ngOnInit() {
    this.addForm = this.formBuilder.group({
      StartDate: [''],
      EndDate: [''],
      Comment: [''],
      DriverLicense: [''],
      CarId: [''],
      Car: null,
      DriverLicenseNavigation: null
    });
  }

  OnSubmit(value: any) {
    this.ordersService.postOrders(value).subscribe(
      res => {
        console.log('Submitted successfully');
        this.ordersService.getOrders();
      },
      err => {
        console.log(err);
      }); }
}
