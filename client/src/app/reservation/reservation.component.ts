import { Component, OnInit } from '@angular/core';
import { Reservation } from '../shared/models/reservation';
import { ReservationService } from './reservation.service';

@Component({
  selector: 'app-reservation',
  templateUrl: './reservation.component.html',
  styleUrls: ['./reservation.component.scss']
})
export class ReservationComponent implements OnInit {
 
 myRes : Reservation[] = [];
 guestName : string = '';
 reservation? : Reservation;

 constructor(private reservationService: ReservationService){}
  
 ngOnInit(): void {
   this.getReservation();
  }

  getReservation(): void{
    this.reservationService.getReservations().subscribe({
      next:(response : Reservation[]) => this.myRes = response,
      error: error =>(console.log(error))
      
    });
  }

}
