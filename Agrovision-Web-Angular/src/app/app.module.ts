import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { CalculatorComponent } from './components/calculator/calculator.component';
import { AgentsComponent } from './components/agents/agents.component';
import { FieldsComponent } from './components/fields/fields.component';
import { SprayersComponent } from './components/sprayers/sprayers.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import {
  MatButtonModule,
  MatCardModule,
  MatCheckboxModule,
  MatDialogModule,
  MatFormFieldModule, MatGridListModule, MatIconModule,
  MatInputModule, MatListModule,
  MatPaginatorModule,
  MatProgressSpinnerModule,
  MatSelectModule, MatSidenavModule,
  MatSliderModule,
  MatSnackBarModule,
  MatSpinner,
  MatTableModule, MatToolbarModule,
} from '@angular/material';
import { OverlayModule } from '@angular/cdk/overlay';
import {NavigationComponent} from './navigation/navigation.component';

@NgModule({
  declarations: [
    AppComponent,
    NavigationComponent,
    CalculatorComponent,
    AgentsComponent,
    FieldsComponent,
    SprayersComponent,
  ],
  imports: [
    BrowserModule.withServerTransition({appId: 'ng-cli-universal'}),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      {path: '', component: CalculatorComponent, pathMatch: 'full'},
      {path: 'calculator', component: CalculatorComponent},
      {path: 'agents', component: AgentsComponent},
      {path: 'fields', component: FieldsComponent},
      {path: 'sprayers', component: SprayersComponent},
    ]),
    BrowserAnimationsModule,
    MatButtonModule,
    MatCardModule,
    MatCheckboxModule,
    MatDialogModule,
    MatFormFieldModule,
    MatInputModule,
    OverlayModule,
    MatPaginatorModule,
    MatProgressSpinnerModule,
    MatSelectModule,
    MatSnackBarModule,
    MatSliderModule,
    MatTableModule,
    MatListModule,
    MatGridListModule,
    MatSidenavModule,
    MatToolbarModule,
    MatIconModule
  ],
  providers: [ ],
  entryComponents: [
    MatSpinner],
  bootstrap: [AppComponent]
})
export class AppModule { }
