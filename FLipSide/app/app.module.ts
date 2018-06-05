import { NgModule }      from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { ProductListComponent } from "./product/product-list.component";
import { AppComponent }  from './app.component';
import { AppRoutingModule } from './product/app-routing.module';

@NgModule({
  imports: [BrowserModule, AppRoutingModule],
  declarations: [ AppComponent ],
  bootstrap:    [ AppComponent ]
})
export class AppModule { }
