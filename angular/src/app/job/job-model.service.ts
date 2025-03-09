import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';

export interface JobModelMessage{
  jobId: string,
  pipelineName: string
}

@Injectable({
  providedIn: 'root'
})
export class JobModelService {

  private messageSource = new BehaviorSubject<JobModelMessage>({jobId: "", pipelineName: ""});
  currentMessage = this.messageSource.asObservable();

  constructor() { }

  changeMessage(message: JobModelMessage) {
    this.messageSource.next(message)
  }

}