import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Reservation } from './models/reservation';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit {
  title = 'table reservation api';
  reservations: Reservation[] = [];


constructor(private http: HttpClient){}
  

ngOnInit(): void {
   this.http.get<Reservation[]>('https://localhost:5001/api/reservation?').subscribe({
    next: (response : Reservation[]) => this.reservations = response,
    error : error => console.log(error),
      complete: () => {
        console.log('request complete');
      }
   })
  }


}
