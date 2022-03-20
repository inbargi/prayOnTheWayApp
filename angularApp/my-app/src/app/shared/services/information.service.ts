import { Injectable } from '@angular/core';
import { AskMinyan } from '../models/askMinyan.model';
import { Result } from '../models/result.model';

@Injectable({
  providedIn: 'root'
})
export class InformationService {
   askMinyan : AskMinyan = new AskMinyan();
   resultAlgorithm !: Result;
  constructor() { }
}
