import { Component, inject, OnInit } from '@angular/core';
import { ShopService } from '../../core/services/shop.service';
import { Pagination } from '../../shared/models/pagination';
import { Product } from '../../shared/models/product';
import { HttpErrorResponse } from '@angular/common/http';
import { MatCard } from '@angular/material/card';

@Component({
  selector: 'app-shop',
  imports: [
    MatCard
  ],
  templateUrl: './shop.component.html',
  styleUrl: './shop.component.scss',
})

export class ShopComponent implements OnInit {

  private shopService = inject(ShopService);

  products: any = [];

    ngOnInit(): void {
    this.shopService.getProducts().subscribe({
      next: (response: Pagination<Product>) => this.products = response.data,
      error: (err: HttpErrorResponse) => console.log(err.message)
    });
  }
}
