import { Injectable } from '@angular/core';
import { AskMinyan } from '../models/askMinyan.model';

@Injectable({
  providedIn: 'root'
})
export class InformationService {
   askMinyan:AskMinyan={};
  constructor() { }
}
