import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';

export interface Message{
  experimentId: string,
  pipelineId: string,
  displayName: string,
  pipelineName: string
}

@Injectable({
  providedIn: 'root'
})
export class PipelineJobService {

  private messageSource = new BehaviorSubject<Message>({experimentId: "", pipelineId: "", displayName: "", pipelineName: ""});
  currentMessage = this.messageSource.asObservable();

  constructor() { }

  changeMessage(message: Message) {
    this.messageSource.next(message)
  }

}