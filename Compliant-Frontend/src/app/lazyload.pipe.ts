import { Injectable, Pipe, PipeTransform } from '@angular/core';

/*
 * @author: Gomtesh
 */
@Pipe({
  name: 'lazyLoadData',
  pure: false,
})
@Injectable()
export class LazyLoadDataPipe implements PipeTransform {
  intervalFlag: number = 0;
  loadRows: number = 50;
  items = [];

  /*
   * @param items : object from array
   * @param intialLoadRows : number of row we want to load initially
   * @param intervalLoadRows : number of records want to lazy load in the background
   * @param interval : interval at which next record we want to lazy load in the background
   *
   * @returns : list of objects with respect to : from and to index
   */
  transform(
    items: any,
    intialLoadRows: number = 50,
    intervalLoadRows: number = 100,
    interval: number = 100
  ): any {
    this.items = items;
    if (this.intervalFlag == 0) {
      this.intervalFlag = 1;
      const that = this;
      this.loadRows = intialLoadRows;
      const inter = setInterval(function () {
        if (that.items && that.items?.length) {
          if (that.items?.length > that.loadRows) {
            that.loadRows = that.loadRows + intervalLoadRows;
          } else {
            if (inter) {
              clearInterval(inter);
            }
          }
        }
      }, interval);
    }
    if (items && items?.length) {
      console.log('counter', this.loadRows);
      return items.slice(0, this.loadRows);
    }
  }
}
