import { Yorum } from './../models/Yorum';
import { Uye } from './../models/Uye';
import { Haber } from './../models/Haber';
import { Kategori } from './../models/Kategori';
import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class ApiService {
  apiUrl = "http://localhost:57242/api/";

  constructor(
    public http: HttpClient

  ) { }
//OTURUM İŞLEM BAŞLANGICI
  tokenAl(kadi: string, parola: string) {
    var data = "username=" + kadi + "&password=" + parola + "&grant_type=password";
    var reqHeader = new HttpHeaders({ "Content-Type": "application/x-www-form-urlencoded" });
    return this.http.post(this.apiUrl+"/token", data, {headers:reqHeader} );
  }
  oturumKontrol(){
    if (localStorage.getItem("token")){
      return true;
    }
    else{
      return false;
    }
  }
//OTURUM İŞLEM SONU //


/* API */

KategoriListe(){
  return this.http.get(this.apiUrl+"/kategoriliste");
}
KategoriById(katId:number){
  return this.http.get(this.apiUrl+"/kategoribyid/"+katId);
}
KategoriEkle(kat:Kategori){
  return this.http.post(this.apiUrl+"/kategoriekle",kat);
}
KategoriDuzenle(kat:Kategori){
  return this.http.put(this.apiUrl+"/kategoriduzenle",kat);
}
KategoriSil(katId:number){
  return this.http.delete(this.apiUrl+"/kategorisil/"+katId);
}
HaberListeByKatId(katId:number){
  return this.http.get(this.apiUrl+"/haberlistebykatid/"+katId);
}
HaberListeByUyeId(uyeId:number){
  return this.http.get(this.apiUrl+"/haberlistebyuyeid/"+uyeId);
}
HaberListe(){
  return this.http.get(this.apiUrl+"/haberliste");
}
HaberById(haberId:number){
  return this.http.get(this.apiUrl+"/haberbyid/"+haberId);
}
HaberEkle(haber:Haber){
  return this.http.post(this.apiUrl+"/haberekle",haber);
}
HaberDuzenle(haber:Haber){
  return this.http.put(this.apiUrl+"/haberduzenle",haber);
}
HaberSil(haberId:number){
  return this.http.delete(this.apiUrl+"/habersil/"+haberId);
}
UyeListe(){
  return this.http.get(this.apiUrl + "/uyeliste");
}
UyeById(uyeId:number){
  return this.http.get(this.apiUrl + "/uyebyid/" + uyeId);
}
UyeEkle(uye:Uye){
  return this.http.post(this.apiUrl + "/uyeekle",uye);
}
UyeDuzenle(uye:Uye){
  return this.http.put(this.apiUrl + "/uyeduzenle", uye);
}
UyeSil(uyeId:number){
  return this.http.delete(this.apiUrl + "/uyesil/"+uyeId);
}
YorumListe(){
  return this.http.get(this.apiUrl + "/yorumliste");
}
YorumListeByUyeId(uyeId:number){
  return this.http.get(this.apiUrl + "/yorumlistebyuyeid/"+uyeId);
}
YorumListeByHaberId(haberId:number){
  return this.http.get(this.apiUrl + "/yorumlistebyhaberid/"+haberId);
}
YorumById(yorumId:number){
  return this.http.get(this.apiUrl + "/yorumbyid/" + yorumId);
}
YorumEkle(yorum:Yorum){
  return this.http.post(this.apiUrl + "/yorumekle",yorum);
}
YorumDuzenle(yorum:Yorum){
  return this.http.put(this.apiUrl + "/yorumduzenle", yorum);
}
YorumSil(yorumId:number){
  return this.http.delete(this.apiUrl + "/yorumsil/"+yorumId);
}




}
