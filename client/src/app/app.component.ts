import { Component, inject, OnInit } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { HeaderComponent } from "./layout/header/header.component";
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Product } from './shared/models/product';
import { Pagination } from './shared/models/pagination';
import { ShopService } from './core/services/shop.service';

@Component({
  selector: 'app-root',
  imports: [RouterOutlet, HeaderComponent],
  templateUrl: './app.component.html',
  styleUrl: './app.component.scss'
})
export class AppComponent implements OnInit {

  protected readonly title = 'Skinet Store';

  private shopService = inject(ShopService);

  products: any = [];

    ngOnInit(): void {
    this.shopService.getProducts().subscribe({
      next: (response: Pagination<Product>) => this.products = response.data,
      error: (err: HttpErrorResponse) => console.log(err.message)
    });
  }
}
