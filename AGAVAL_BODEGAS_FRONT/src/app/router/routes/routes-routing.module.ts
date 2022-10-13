import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { MsalGuard } from '@azure/msal-angular';
import { HomeComponent } from 'src/app/components/home/home.component';

import { ListarBodegasComponent } from 'src/app/components/bodega/list/list.component';
import { CrearBodegaComponent } from 'src/app/components/bodega/crear/crear.component';

const routes: Routes = [
  { path: 'home', component: HomeComponent },
  { path: 'bodegas', component: ListarBodegasComponent, canActivate: [MsalGuard] },
  { path: 'bodega/:codigo', component: CrearBodegaComponent, canActivate: [MsalGuard] },
  { path: 'bodega', component: CrearBodegaComponent, canActivate: [MsalGuard] },
  { path: '',   redirectTo: '/home', pathMatch: 'full' },
  { path: '**', component: HomeComponent }
];

@NgModule({
  imports: [RouterModule.forChild(routes), RouterModule.forRoot(routes, {
    initialNavigation: 'enabledBlocking'
  })],
  exports: [RouterModule]
})
export class RoutesRoutingModule { }
