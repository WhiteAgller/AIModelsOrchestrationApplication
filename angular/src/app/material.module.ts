import { NgModule } from '@angular/core';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatSelectModule } from '@angular/material/select';
import { MatInputModule } from '@angular/material/input';
import { MatTableModule } from '@angular/material/table'
import { MatButtonModule } from '@angular/material/button';
import { MatSortModule } from '@angular/material/sort';
import { CdkTableModule } from '@angular/cdk/table';
import { MatIconModule } from '@angular/material/icon';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';
import { MatListModule } from '@angular/material/list';
import { MatCardModule } from '@angular/material/card';
import { MatDividerModule } from '@angular/material/divider';

@NgModule ({
  imports: [
    MatFormFieldModule,
    MatSelectModule,
    MatInputModule,
    MatTableModule,
    MatButtonModule,
    MatSortModule,
    CdkTableModule,
    MatIconModule,
    MatProgressSpinnerModule,
    MatListModule,
    MatCardModule,
    MatDividerModule
  ],
  exports: [
    MatFormFieldModule,
    MatSelectModule,
    MatInputModule,
    MatTableModule,
    MatButtonModule,
    MatSortModule,
    CdkTableModule,
    MatIconModule,
    MatProgressSpinnerModule,
    MatListModule,
    MatCardModule,
    MatDividerModule
  ]
})
export class MaterialModule {}