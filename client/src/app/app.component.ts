import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit{
  title = 'Skinet';
  products: any[] = [];
  constructor(private http: HttpClient) {

  }

  ngOnInit(): void {
    this.http.get('http://localhost:5000/api/products').subscribe((response: any) => {
      this.products = response.data;
      console.log(response);
    }, error => {
      console.log(error);
    });
  }
}
