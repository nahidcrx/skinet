import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { error } from 'console';
import { response } from 'express';
import { IProduct } from './models/product';
import { IPagination } from './models/pagination';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrl: './app.component.scss'
})
export class AppComponent implements OnInit{
  title = 'SkiNet';
  products: IProduct[] = [];

  constructor(private http: HttpClient){}
  ngOnInit(): void {
    this.http.get<IPagination>("https://localhost:44310/api/Products?PageSize=50").subscribe(
      (response: IPagination) =>
        {
          this.products = response.data;
        }, error=> {
          console.log(error);
        }
    );
  }
}
