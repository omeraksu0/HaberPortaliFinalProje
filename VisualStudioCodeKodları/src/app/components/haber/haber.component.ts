import { Component, OnInit, ViewChild } from '@angular/core';
import { Haber } from 'src/app/models/Haber';
import { MatSort } from '@angular/material/sort';
import { MatPaginator } from '@angular/material/paginator';
import { MatDialog, MatDialogRef } from '@angular/material/dialog';
import { Kategori } from 'src/app/models/Kategori';
import { ConfirmDialogComponent } from '../dialogs/confirm-dialog/confirm-dialog.component';
import { ApiService } from 'src/app/services/api.service';
import { MyAlertService } from 'src/app/services/myAlert.service';
import { MatTableDataSource } from '@angular/material/table';
import { Sonuc } from 'src/app/models/Sonuc';
import { HaberDialogComponent } from '../dialogs/haber-dialog/haber-dialog.component';
import { ActivatedRoute } from '@angular/router';


@Component({
  selector: 'app-haber',
  templateUrl: './haber.component.html',
  styleUrls: ['./haber.component.scss']
}) 
export class HaberComponent implements OnInit {
  dialogBaslik: string;
  dialogMesaj: string;
  dialogIslem: boolean;
  kategoriler: Kategori[];
 haberler:Haber[];
 katId:number;
 haberUyeId:number;

 secKat:Kategori;
 datasource:any;
 displayedColums = ['haberBaslik','haberTarih','haberOkunma','haberDetay'];
 @ViewChild(MatSort) sort:MatSort;
 @ViewChild(MatPaginator) paginator:MatPaginator;
  dialogRef:MatDialogRef<HaberDialogComponent>;
  ConfirmDialogRef:MatDialogRef<ConfirmDialogComponent>;
  constructor(
    public apiServis:ApiService,
    public alert:MyAlertService,
    public matDialog: MatDialog,
    public route: ActivatedRoute
  ) { }

  ngOnInit() {
    this.KategoriListele();
    this.haberUyeId=parseInt(localStorage.getItem("uid"));
    this.route.params.subscribe(p=>{
      if(p.katId){
        this.KategoriById();
        this.katId=p.katId;
      }
    });

  }
  KategoriById(){
    this.apiServis.KategoriById(this.katId).subscribe((d:Kategori)=>{
      this.secKat = d;
      this.HaberListele();
    });
  }
  HaberListele(){
    this.apiServis.HaberListeByKatId(this.katId).subscribe((d:Haber[])=>{
      this.haberler = d;
      this.datasource = new MatTableDataSource(d);
      this.datasource.sort=this.sort;
      this.datasource.paginator=this.paginator;
    });
  }
  KategoriListele(){
    this.apiServis.KategoriListe().subscribe((d:Kategori[])=> {
      this.kategoriler=d;
  });
  }
  Filtrele(e){
    var deger=e.target.value;
    this.datasource.filter=deger.trim().toLowerCase();
    if(this.datasource.paginator){
      this.datasource.paginator.firstPage();
    }
   }
   KategoriSec(kat: Kategori){
    this.katId = kat.kategoriId;
    this.HaberListele();
   }
Ekle(){
    var yeniKayit:Haber = new Haber();
    this.dialogRef=this.matDialog.open(HaberDialogComponent,{
      width:'800px',
      data:{
        kayit:yeniKayit,
        islem:'ekle'
      }
    });
    this.dialogRef.afterClosed().subscribe(d=>{
      if (d) {

        yeniKayit=d;
        yeniKayit.haberTarih=new Date();
        yeniKayit.haberOkuma=0;
        yeniKayit.haberUyeId=this.haberUyeId;

        this.apiServis.HaberEkle(yeniKayit).subscribe((s:Sonuc)=>{
          this.alert.AlertUygula(s);
          if(s.islem){
            this.HaberListele();
          }
        });
      }
    });
}
  Duzenle(kayit: Haber){
    this.dialogRef=this.matDialog.open(HaberDialogComponent,{
      width:'800px',
      data:{
        kayit:kayit,
        islem:'duzenle'
      }
    });
    this.dialogRef.afterClosed().subscribe(d=>{
      if (d){
        
        this.apiServis.HaberDuzenle(d).subscribe((s:Sonuc)=>{
          this.alert.AlertUygula(s);
          if (s.islem){
            this.HaberListele();
          }
        });
      }
    });

  }
  Detay(kayit: Haber){
    this.dialogRef=this.matDialog.open(HaberDialogComponent,{
      width:'800px',
      data:{
        kayit:kayit,
        islem:'detay'
      }
    });
    
  }

  Sil(kayit:Haber){
    this.ConfirmDialogRef=this.matDialog.open(ConfirmDialogComponent,{
      width:'600px'
    }); 

    this.ConfirmDialogRef.componentInstance.dialogMesaj= kayit.haberBaslik +"  --> Başlıklı Haber Silinecektir Onaylıyor Musunuz ?"
    this.ConfirmDialogRef.afterClosed().subscribe(d=>{
      if (d) {
        this.apiServis.KategoriSil(kayit.haberKategoriId).subscribe((s:Sonuc)=>{
          this.alert.AlertUygula(s);
          if(s.islem){
            this.HaberListele();
          }
        });
      }
    });
  }
}
  
