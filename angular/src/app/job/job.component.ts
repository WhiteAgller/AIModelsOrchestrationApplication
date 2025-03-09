import { Component } from '@angular/core';
import { JobService } from '@proxy/job';
import { Message, PipelineJobService } from '../pipeline/pipeline-job.service';
import { Subscription, interval, takeWhile } from 'rxjs';
import { JobStatusDto } from '@proxy/dto/job';
import { JobModelService } from './job-model.service';
import { AvaibleConfigService } from '../services/avaibleConfig.service';

@Component({
  selector: 'app-job',
  templateUrl: './job.component.html',
  styleUrls: ['./job.component.scss']
})
export class JobComponent {
  message: Message;
  jobs: JobStatusDto[] = []
  finishedJobs: string[] = []
  
  constructor(private jobService: JobService,
              private pipelineJobService: PipelineJobService,
              private jobModelService: JobModelService,
              private avaibleConfigService: AvaibleConfigService){}

  ngOnInit(): void {
    this.avaibleConfigService.hasConfig().then(hasConfig => {
      if (!hasConfig) {
        return;
      }
      this.loadJobs();
    });
  
    this.pipelineJobService.currentMessage.subscribe(async message => {
      this.message = message;
      if (this.message.experimentId == "" || this.message.pipelineId == "") {
        return;
      }
  
      try {
        const jobs = await this.jobService.getList().toPromise();
        
        if(jobs.find(job => job.pipelineId == message.pipelineId) != null)
        {
          return;
        }
  
        this.jobService.create(message).subscribe(response => {
          const jobId = response.id;
          this.getAllJobs();
          this.process(jobId, message.pipelineId, message.experimentId);
        });
      } catch (error) {
        console.error(error);
      }
    });
  }

  private getAllJobs(){
    this.jobService.getList().subscribe(response => {
      this.jobs = response;
    });
  }

  private loadJobs(){
    this.jobService.getList().subscribe(response => {
      response.forEach(job => {
        if(this.jobs.find(x => x.id == job.id) == null){
          this.jobs.push(job);
        }
        this.process(job.id, job.pipelineId, job.experimentId);
      })
    });
  }

  private process(jobId: string, pipelineId: string, experimentId: string){
    let subscription: Subscription;
    const intervalTime = 10000;
    let procesFinished = false;
    
    subscription = interval(intervalTime).pipe(
      takeWhile(() => !procesFinished) 
    ).subscribe(() => {
      this.jobService.getJobByPipelineIdAndExperimentId(pipelineId, experimentId).subscribe(response => {
        if (response.status.statusCode == 5) {
          this.jobService.delete(jobId).subscribe(_ => {
            procesFinished = true;
            this.sendDataToModel();
            this.finishedJobs.push(jobId);
            this.jobs.filter(job => job.id != jobId);
          })
        }
      });
    });
  }

  private sendDataToModel(){
    this.jobModelService.changeMessage({jobId: this.message.pipelineId, pipelineName: this.message.pipelineName});
  }

}
