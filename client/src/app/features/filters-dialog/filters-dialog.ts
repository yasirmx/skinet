import { Component, inject } from '@angular/core';
import { ShopService } from '../../core/services/shop.service';
import { MatDivider } from '@angular/material/divider';
import { MatSelectionList } from '@angular/material/list';
import { MatListOption } from '@angular/material/list';
import { MatButton } from '@angular/material/button';

@Component({
  selector: 'app-filters-dialog',
  imports: [MatDivider, MatSelectionList, MatListOption, MatButton],
  templateUrl: './filters-dialog.html',
  styleUrl: './filters-dialog.scss',
})
export class FiltersDialog {
 shopService = inject(ShopService);
}
