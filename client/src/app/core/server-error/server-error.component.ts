import { Component } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-server-error',
  templateUrl: './server-error.component.html',
  styleUrls: ['./server-error.component.scss']
})
export class ServerErrorComponent {
error: any;
//TODO invastigate server-error details not working
  constructor(private router: Router){
const navigation = this.router.getCurrentNavigation();
this.error = navigation?.extras?.state?.['error'];

  }


}
