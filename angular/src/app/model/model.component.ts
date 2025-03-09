import { Component } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, ValidationErrors, ValidatorFn, Validators } from '@angular/forms';
import { ModelsInfoDto } from '@proxy/dto/model';
import { PipelineEndpointDto } from '@proxy/dto/pipeline';
import { ModelService } from '@proxy/model';
import { PipelineService } from '@proxy/pipeline';
import { ValidatorsService } from '../validators/validators.service';
import { FormService } from '../form/form-service';
import { JobModelService } from '../job/job-model.service';
import { ModelType } from '../pipeline/pipeline.component';
import { AvaibleConfigService } from '../services/avaibleConfig.service';

@Component({
  selector: 'app-model',
  templateUrl: './model.component.html',
  styleUrls: ['./model.component.scss']
})
export class ModelComponent {

  models: ModelsInfoDto[] = [];
  myForm: FormGroup;
  pipelines: PipelineEndpointDto[] = [];
  inputForm: FormGroup = new FormGroup({});
  outputForm: FormGroup = new FormGroup({});

  constructor(private modelService: ModelService,
              private fb: FormBuilder,
              private pipelineService: PipelineService,
              private validatorsSerivce: ValidatorsService,
              private formService: FormService,
              private jobModelService: JobModelService,
              private avaibleConfigService: AvaibleConfigService){ }

  ngOnInit(){
    this.myForm = this.fb.group({
      environmentName: ['', Validators.required],
      port: ['', Validators.required],
      pipelineName: ['', Validators.required]
    });
    
    this.avaibleConfigService.hasConfig().then(hasConfig => {
      if(!hasConfig){
        return;
      }
    
    this.modelService.getList().subscribe(response => {
      this.models = response;
      this.myForm.controls.port.addAsyncValidators([this.validatorsSerivce.uniqueNameValidator(this.models, "port")]);
      this.updateFormControls();
    });
    this.pipelineService.getList().subscribe(response => {
      this.pipelines = response;
    });

    this.jobModelService.currentMessage.subscribe(message => {
      const models = this.models.filter(x => x.pipelineName === message.pipelineName);
      models.forEach(model => {
        this.modelService.deployModelByPipelineIdAndPortAndPipelineName(message.jobId, model.port, model.pipelineName).subscribe(result => {
          this.writeToOutput(model.id, result);
          this.modelService.getModelLatestVersionByPipelineId(message.jobId).subscribe(response => {
            const model = this.models.find(model => model.pipelineName === message.pipelineName);
            const date = new Date().toISOString();
            model.name = response.modelName;
            model.version = response.modelVersion;
            model.lastUpdate = new Date(date);
            this.getAccuracy(model.id).then(acc => model.accuracy = Number(acc.toFixed(2)));
            this.modelService.update(model).subscribe(_ => {
              this.refhreshModels();
            });
          });
        });
      });
    });
  });
  }

  async get_performance(model_id: string){
    const port = this.getModelPortByModelId(model_id);
    const type: string = await this.getPipelineType(port);
    this.modelService.getPerformanceByPortAndTypeAndJson(port, ModelType[type], false).subscribe(response => {
      const winUrl = URL.createObjectURL(new Blob([response], { type: 'text/html' }));
      window.open(winUrl);
      console.log(model_id)
      this.setAccuracy(model_id);
    });
  }

  get_data_drift(model_id: string){
    const port = this.getModelPortByModelId(model_id);
    this.modelService.getDataDriftByPort(port).subscribe(response => {
      const winUrl = URL.createObjectURL(new Blob([response], { type: 'text/html' }));
      window.open(winUrl);
    });
  }

  create(){
    const date = new Date();
    const body: ModelsInfoDto = {
      name: "",
      pipelineName: this.myForm.value.pipelineName,
      port: this.myForm.value.port,
      accuracy: 0,
      lastUpdate: new Date(date.toISOString()),
      version: "0",
      environmentName: this.myForm.value.environmentName
    };
    this.modelService.create(body).subscribe(_ =>{
      this.refhreshModels();
      this.myForm = this.formService.resetFormGroup(this.myForm);
    });
  }

  delete(id: string){
    this.modelService.delete(id).subscribe(_ => {
      this.refhreshModels();
      
    });
  }

  async predict(modelId: string) {
    try {
      const model = this.models.find(model => model.id === modelId);
      const input = this.inputForm.controls[modelId].value;
      const inputList = input.split(",");
      const response = await this.modelService.predictByPortAndInput(model.port, inputList).toPromise();
      this.writeToOutput(model.id, response);
      this.inputForm.controls[modelId].setValue("");
      this.setAccuracy(modelId);
    } catch (error) {
      console.error("Error predicting:", error);
    }
  }

  async getAccuracy(modelId: string) {
    const port = this.getModelPortByModelId(modelId);
    const type: string = await this.getPipelineType(port);
  
    return new Promise<number>((resolve, reject) => {
      this.modelService.getPerformanceByPortAndTypeAndJson(port, ModelType[type], true).subscribe(response => {
        const regex = /{\\"current\\": {\\"accuracy\\": ([0-9.]+)/;
        const match = response.match(regex);
        if (match && match.length > 1) {
          resolve(parseFloat(match[1]));
        } else {
          reject(new Error("Accuracy not found"));
        }
      }, error => {
        reject(error);
      });
    });
  }
  
  async setAccuracy(modelId: string) {
    try {
      const acc: number = await this.getAccuracy(modelId);
      const model = this.models.find(model => model.id === modelId);
      model.accuracy = Number(acc.toFixed(2));
      this.modelService.update(model).subscribe();
    } catch (error) {
      console.error("Error setting accuracy:", error);
    }
  }

  private async getPipelineType(port: string){
    await this.pipelineService.getList().subscribe(response => {
      return response.find(x => x.restEndpoint === port)
    });
    return "";
  }

  private writeToOutput(modelId: string, text){
    const control = this.outputForm.controls[modelId];
    const prevText = control.value;
    const newText = `${prevText === "" ? "" : prevText + "\n"}${text}`;
    control.setValue(newText);
  }

  private getModelPortByModelId(modelId: string){
    const model = this.models.find(x => x.id === modelId);
    return model.port;
  }

  private refhreshModels(){
    this.modelService.getList().subscribe(response => {
      this.models = response;
    });
  }

  private updateFormControls(){
    this.models.forEach(model => {
      this.inputForm.addControl(model.id, new FormControl(''));
      this.outputForm.addControl(model.id, new FormControl(''));
    });
  }
}
