import { Component, OnInit } from '@angular/core';
import { Reservation } from '../models/reservation';
import { ReservationService } from './reservation.service';

@Component({
  selector: 'app-reservation',
  templateUrl: './reservation.component.html',
  styleUrls: ['./reservation.component.scss']
})
export class ReservationComponent implements OnInit {
 minDate = new Date();
 myRes : Reservation[] = []

 constructor(private reservationService: ReservationService){}
  
 ngOnInit(): void {
   this.getReservation();
  }

  getReservation(){
    this.reservationService.getReservations().subscribe({
      next:(response : Reservation[]) => this.myRes = response,
      error: error =>(console.log(error))
      
    });
  }

}
