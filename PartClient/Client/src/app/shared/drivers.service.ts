import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { ThrowStmt } from "@angular/compiler";

export  interface Drivers{
    NumberDriverLicense:string,
    FirstName:string,
    LastName:string,
    BirthDate:Date,
    Orders:any
  }

@Injectable({providedIn:'root'})    
export class DriversService{
    public drivers:Drivers[] = []
    constructor (private http: HttpClient){

    }

    fetchDrivers(){
       this.http.get('http://localhost:62131/api/drivers').
       toPromise().then(res=> this.drivers = res as Drivers[]);
    }
}