import { Component, inject, OnInit } from '@angular/core';
import { ShopService } from '../../core/services/shop.service';
import { Pagination } from '../../shared/models/pagination';
import { Product } from '../../shared/models/product';
import { HttpErrorResponse } from '@angular/common/http';
import { MatDialog } from '@angular/material/dialog';
import { ProductItem } from '../product-item/product-item';
import { FiltersDialog } from '../filters-dialog/filters-dialog';
import { MatButton } from '@angular/material/button';
import { MatIcon } from '@angular/material/icon';

@Component({
  selector: 'app-shop',
  imports: [ ProductItem, MatButton, MatIcon ],
  templateUrl: './shop.component.html',
  styleUrl: './shop.component.scss',
})

export class ShopComponent implements OnInit {

  private shopService = inject(ShopService);
  private dialogService = inject(MatDialog);

  products: any = [];

    ngOnInit(): void {
    this.initializeShop();
  }

  initializeShop() {
    this.shopService.getBrands();

    this.shopService.getTypes();

    this.shopService.getProducts().subscribe({
      next: (response: Pagination<Product>) => this.products = response.data,
      error: (err: HttpErrorResponse) => console.log(err.message)
    });
  }

  openFiltersDialog() {
    const dialogRef = this.dialogService.open(FiltersDialog, {
      width: '700px',
      maxWidth: '90vw',
    });
  }
}
