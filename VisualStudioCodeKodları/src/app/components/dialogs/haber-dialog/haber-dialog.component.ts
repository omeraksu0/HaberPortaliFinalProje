import { ApiService } from 'src/app/services/api.service';
import { Kategori } from 'src/app/models/Kategori';
import { Haber } from 'src/app/models/Haber';
import { Component, Inject, OnInit } from '@angular/core';
import { FormGroup, FormBuilder } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';

@Component({
  selector: 'app-haber-dialog',
  templateUrl: './haber-dialog.component.html',
  styleUrls: ['./haber-dialog.component.scss']
})
export class HaberDialogComponent implements OnInit {
  dialogBaslik: string;
  yeniKayit:Haber;
  islem:string;
  frm:FormGroup; 
  kategoriler:Kategori [];
  Jconfig={};


  constructor(
    public dialogRef:MatDialogRef<HaberDialogComponent>,
    public frmBuild:FormBuilder,
    @Inject(MAT_DIALOG_DATA) public data: any,
    public ApiService: ApiService
  ) { 
    this.islem = data.islem;

    if(this.islem=="ekle"){
      this.dialogBaslik="Haber Ekle";
      this.yeniKayit=new Haber();
    }
    if(this.islem=="duzenle"){
      this.dialogBaslik="Haber Düzenle";
      this.yeniKayit = data.kayit;
    }
    if(this.islem=="detay"){
      this.dialogBaslik="Haber Detay";
      this.yeniKayit = data.kayit;
    }
    this.frm=this.FormOlustur();
  }

  ngOnInit() {
    this.KategoriListele();
  }
  FormOlustur(){
  return this.frmBuild.group({
  haberBaslik: [this.yeniKayit.haberBaslik],
  haberDetay: [this.yeniKayit.haberDetay],
  haberKategoriId: [this.yeniKayit.haberKategoriId]

  });
  }
  KategoriListele(){
    this.ApiService.KategoriListe().subscribe((d:Kategori[])=> {
      this.kategoriler=d;
  });
  }

}
