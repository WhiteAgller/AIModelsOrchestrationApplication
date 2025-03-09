import { mapEnumToOptions } from '@abp/ng.core';

export enum ModelType {
  Regression = 0,
  Classification = 1,
}

export const modelTypeOptions = mapEnumToOptions(ModelType);
