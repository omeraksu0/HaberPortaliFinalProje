import { Kategori } from './../../models/Kategori';
import { ApiService } from './../../services/api.service';
import { Component } from '@angular/core';
import { BreakpointObserver, Breakpoints } from '@angular/cdk/layout';
import { Observable } from 'rxjs';
import { map, shareReplay } from 'rxjs/operators';

@Component({
  selector: 'app-main-nav',
  templateUrl: './main-nav.component.html',
  styleUrls: ['./main-nav.component.css']
})
export class MainNavComponent {
  kategoriler:Kategori[];

  isHandset$: Observable<boolean> = this.breakpointObserver.observe(Breakpoints.Handset)
    .pipe(
      map(result => result.matches),
      shareReplay()
    );

  constructor(private breakpointObserver: BreakpointObserver,
    public ApiServis: ApiService
    ) { }
    ngOnInit(): void {
      this.KategoriListele();
    
    }
      KategoriListele() {
        this.ApiServis.KategoriListe().subscribe((d:Kategori[]) => {
          this.kategoriler=d;
        });

      }
    }


