import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { IPagination } from './shared/models/pagination';
import { IProduct } from './shared/models/product';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit{
  title = 'Skinet';
  products: IProduct[] = [];
  constructor(private http: HttpClient) {

  }

  ngOnInit(): void {
    this.http.get<IPagination>('http://localhost:5000/api/products').subscribe((response: IPagination) => {
      this.products = response.data;
      console.log(response);
    }, error => {
      console.log(error);
    });
  }
}