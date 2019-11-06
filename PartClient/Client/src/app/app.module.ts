import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import {RouterModule, Routes} from '@angular/router';

import { AppComponent } from './app.component';
import { DriversComponent } from './drivers/drivers.component';
import { CarsComponent } from './cars/cars.component';
import { OrdersComponent } from './orders/orders.component';
import { OrdersListComponent } from './orders/orders-list/orders-list.component';
import { OrdersAddComponent } from './orders/orders-add/orders-add.component';
import {OrdersService} from './shared/orders.service';
import {FormsModule, ReactiveFormsModule} from '@angular/forms';
import { OrdersFilterComponent } from './orders/orders-filter/orders-filter.component';

const appRoutes: Routes = [
  {path: 'cars', component: CarsComponent},
  {path: 'drivers', component: DriversComponent },
  {path: '', component: OrdersComponent}
];

@NgModule({
  declarations: [
    AppComponent,
    DriversComponent,
    CarsComponent,
    OrdersComponent,
    OrdersListComponent,
    OrdersAddComponent,
    OrdersFilterComponent,
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    RouterModule.forRoot(appRoutes),
    FormsModule,
    ReactiveFormsModule
  ],
  providers: [OrdersService],
  bootstrap: [AppComponent]
})
export class AppModule { }

