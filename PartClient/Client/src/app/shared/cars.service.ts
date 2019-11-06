import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

export interface Cars {
    RegistrationNumber: string;
    Mark: string;
    Model: string;
    CarClass: string;
    YearOfIssue: Date;
    Orders: any;
}
@Injectable({providedIn: 'root'})
export class CarsService {
    public cars: Cars[] = [];
    /**
     *
     */
    constructor(private http: HttpClient) {}

    getCars() {
        this.http.get('http://localhost:62131/api/cars').
        toPromise().then(res => this.cars = res as Cars[]);
    }
}
