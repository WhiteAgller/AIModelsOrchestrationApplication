import { mapEnumToOptions } from '@abp/ng.core';

export enum ModelMethod {
  Regression = 0,
  Classification = 1,
}

export const modelMethodOptions = mapEnumToOptions(ModelMethod);
