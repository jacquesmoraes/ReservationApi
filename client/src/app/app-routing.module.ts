import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { TablesComponent } from './tables/tables.component';
import { ReservationComponent } from './reservation/reservation.component';

const routes: Routes = [
{path:'', component: HomeComponent },
{path: 'table', component: TablesComponent},
{path:'reservation', component:ReservationComponent}

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
