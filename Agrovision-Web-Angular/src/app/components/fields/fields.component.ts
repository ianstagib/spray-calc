import { Component, OnInit } from '@angular/core';
import { DataService } from '../../services/data.service';
import { GenericComponent } from '../../shared/generic.component';
import { MatSnackBar, MatDialog } from '@angular/material';
import {Field} from '../../models/field';
import {animate, state, style, transition, trigger} from '@angular/animations';

@Component({
  selector: 'app-fields',
  templateUrl: './fields.component.html',
  styleUrls: ['./fields.component.css'],
  animations: [
    trigger('detailExpand', [
      state('collapsed', style({height: '0px', minHeight: '0', display: 'none'})),
      state('expanded', style({height: '*'})),
      transition('expanded <=> collapsed', animate('225ms cubic-bezier(0.4, 0.0, 0.2, 1)')),
    ]),
  ],
})

export class FieldsComponent extends GenericComponent<Field> implements OnInit {
  displayColumns: String[] = ['name', 'size', 'options'];

  constructor(
    dataService: DataService<Field>,
    snackBar: MatSnackBar,
    dialog: MatDialog) {
    super('Field', dataService, snackBar);
  }
}

