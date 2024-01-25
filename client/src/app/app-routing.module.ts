import { NgModule } from '@angular/core';
import { PreloadAllModules, RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { TablesComponent } from './tables/tables.component';
import { ReservationComponent } from './reservation/reservation.component';
import { TestErrorComponent } from './core/test-error/test-error.component';
import { ServerErrorComponent } from './core/server-error/server-error.component';
import { authGuard } from './core/guards/auth.guard';

const routes: Routes = [
{path:'', component: HomeComponent },
{path:'test-error', component: TestErrorComponent },
{path:'server-error', component: ServerErrorComponent },
{path: 'table', component: TablesComponent},
{path: 'account', loadChildren: () => import('../app/account/account.module').then(m => m.AccountModule)},
{
  path: 'reservation',  component:ReservationComponent,
  canActivate: [authGuard],  
  loadChildren: () => import('./reservation/reservation.module').then(m => m.ReservationModule)
},
{path: '**', redirectTo:'', pathMatch:'full'}
];

@NgModule({
  imports: [RouterModule.forRoot(routes, {
    preloadingStrategy: PreloadAllModules
  })],
  exports: [RouterModule]
})
export class AppRoutingModule { }
