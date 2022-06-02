import { KategoriComponent } from './components/kategori/kategori.component';

import { HaberComponent } from './components/haber/haber.component';
import { LoginComponent } from './components/login/login.component';
import { HomeComponent } from './components/home/home.component';
import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';


const routes: Routes = [
  {
    path:'',
    component:HomeComponent
  },
  {
    path:'login',
    component:LoginComponent
  },
  {
    path:'haber',
    component:HaberComponent
  },
  {
    path:'haber/:katId',
    component:HaberComponent
  },
  {
    path:'kategori',
    component:KategoriComponent
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
