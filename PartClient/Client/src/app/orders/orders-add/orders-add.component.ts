import { Component, OnInit } from '@angular/core';
import {Orders, OrdersService} from '../../shared/orders.service';
import {FormGroup, NgForm, FormBuilder, Validators} from '@angular/forms';


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
      StartDate: ['', Validators.required],
      EndDate: ['', Validators.required ],
      Comment: [''],
      DriverLicense: ['', Validators.required ],
      CarId: ['', Validators.required ],
      Car: null,
      DriverLicenseNavigation: null
    });
  }
   OnSubmit(value: any) {
    this.ordersService.postOrders(value).subscribe(
      res => {
        this.ordersService.getOrders();
      },
      err => {
        console.log(err);
      }); }
}
