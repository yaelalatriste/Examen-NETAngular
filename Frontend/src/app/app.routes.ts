import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './pages/login/login.component';
import { DashboardComponent } from './pages/dashboard/dashboard.component';
import { AuthGuard } from './guards/auth-guard';
import { ClienteComponent } from './pages/clientes/cliente.component';
import { TiendasComponent } from './pages/tiendas/tiendas.component';
import { ArticulosComponent } from './pages/articulos/articulos.component';

export const routes: Routes = [  // <-- export agregado
  { path: 'login', component: LoginComponent },
  { path: '', component: DashboardComponent, canActivate: [AuthGuard] },
  { path: 'clientes', component: ClienteComponent, canActivate: [AuthGuard] },
  { path: 'tiendas', component: TiendasComponent, canActivate: [AuthGuard] },
  { path: 'articulos', component: ArticulosComponent, canActivate: [AuthGuard] },
  { path: '**', redirectTo: '' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
