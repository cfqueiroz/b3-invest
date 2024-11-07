import { Routes } from '@angular/router';
import { CalculadoraCDBComponent } from './calculadora-cdb/calculadora-cdb.component';

export const routes: Routes = [
  { path: '', redirectTo: '/calculadora-cdb', pathMatch: 'full' },
  { path: 'calculadora-cdb', component: CalculadoraCDBComponent },
  // ... outras rotas ...
];
