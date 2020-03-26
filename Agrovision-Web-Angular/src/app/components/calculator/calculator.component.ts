import { environment } from '../../../environments/environment';
import {Component, DoCheck, Input} from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Agent } from '../../models/agent';
import {Field} from '../../models/field';
import {Sprayer} from '../../models/sprayer';

@Component({
  selector: 'app-basic-calculator',
  templateUrl: './calculator.component.html',
  styleUrls: ['./calculator.component.css']
})
export class CalculatorComponent implements DoCheck {
  agentSelect: Agent[] = new Array();
  fieldSelect: Field[] = new Array();
  sprayerSelect: Sprayer[] = new Array();
  selectedAgent: Agent;
  selectedFields: Field[] = new Array();
  selectedSprayer: Sprayer;

  @Input() totalFieldSize: number = 0;
  @Input() dosage: number = 0;
  @Input() rateMin: number = 0;
  @Input() rateMax:  number = 0;

  agentNeeded: number = 0;
  additionalWaterMin: number = 0;
  additionalWaterMax: number = 0;

  constructor(
    private http: HttpClient) {
      this.loadAgents();
      this.loadFields();
      this.loadSprayers();
  }

  loadAgents() {
       this.http.get<Agent[]>(environment.api + '/agent').toPromise().then((result) => {
         this.agentSelect = result;
       });
  }

  loadFields() {
    this.http.get<Field[]>(environment.api + '/field').toPromise().then((result) => {
      this.fieldSelect = result;
    });
  }

  loadSprayers() {
    this.http.get<Sprayer[]>(environment.api + '/sprayer').toPromise().then((result) => {
      this.sprayerSelect = result;
    });
  }

  addAgent(input: Agent) {
    this.selectedAgent = input;
    this.dosage = input.recommendedDosage;
  }

  addSprayer(input: Sprayer) {
    this.selectedSprayer = input;
    this.rateMin = input.rateMin;
    this.rateMax = input.rateMax;
  }

  count(array, key) {
    return array.reduce(function (r, a) {
      return r + a[key];
    }, 0);
  }
  calcTotalSize() {
    this.totalFieldSize = this.count(this.selectedFields, 'size');
  }

  calculateResult() {
    this.agentNeeded = this.dosage * this.totalFieldSize;
    const min = (this.rateMin - this.dosage) * this.totalFieldSize;
    const max = (this.rateMax - this.dosage) * this.totalFieldSize;

    if (min < 0) {
      this.additionalWaterMin = 0;
    } else {
      this.additionalWaterMin = min;
    }

    if (max < 0) {
      this.additionalWaterMax = 0;
    } else {
      this.additionalWaterMax = max;
    }
  }

  clear() {
    this.totalFieldSize = 0;
    this.dosage = 0;
    this.rateMin = 0;
    this.rateMax = 0;
    this.selectedAgent = undefined;
    this.selectedSprayer = undefined;
    this.selectedFields = [];
  }

  ngDoCheck() {
    this.calculateResult();
  }
}
