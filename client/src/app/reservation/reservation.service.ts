import { HttpClient } from '@angular/common/http';
import { Injectable, OnInit } from '@angular/core';
import { Reservation } from '../models/reservation';

@Injectable({
  providedIn: 'root'
})
export class ReservationService {
  baseUrl = 'https://localhost:5001/api/'

  constructor(private http : HttpClient) { }

  getReservations(){
    return this.http.get<Reservation[]>(this.baseUrl + 'reservation');
  }
  getReservation(id: number){
    return this.http.get<Reservation[]>(this.baseUrl + 'reservation' + id);
  }
}
