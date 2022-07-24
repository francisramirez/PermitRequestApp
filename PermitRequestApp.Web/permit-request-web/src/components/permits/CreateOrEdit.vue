<template>
      <h1 id="tableLabel">{{ title }}</h1>
      <p>From here you can make requests for permits</p>
     <hr/>
     <div class="mx-auto" style="width: 500px;">
         <div class="row" style="text-align: center">
        <div class="col-md-12">
                <form >
                <div class="form-group">
                    <input type="text" 
                           class="form-control" 
                           id="employeeName" 
                           placeholder="Enter employee Name" 
                           v-model="permit.EmployeeName">
                </div>
                 <div class="form-group">
                    <input type="text" 
                    class="form-control" 
                    id="employeeLastName" 
                    placeholder="Enter employee last name" 
                    v-model="permit.EmployeeLastName">
                </div>

                <div class="form-group">


                    <select class="form-control" id="permitType" v-model="permit.PermitTypeId">
                    <option>Select Permit Type</option>
                    
                       <option 
                           v-for="permitType in permitTypes" v-bind:key="permitType" :value="permitType.Id">{{permitType.Description}}
                       </option>
                    </select>
                </div>
              <div class="form-group">
                    <input type="text"  
                    class="form-control date" 
                    id="permitDate" 
                    placeholder="Format permit date (mm/dd/yyyy)" 
                    v-model="permit.PermitDateDesc">
                </div>
               
                
                  <button @click="Cancel" type="button" class="btn btn-danger">Cancel</button>
                  <button type="button" class="btn btn-primary m-2" v-on:click="SavePermit">Submit</button>
              
                 
                </form>

        </div>
     </div>
     </div>

</template>

<script>
   import { useRoute  } from "vue-router";
   import axios from 'axios';

   
   const urlBase = 'http://localhost:37803';

     let Id =0;

    export default {
        setup(){
            const router = new useRoute();
            Id = router.params.id;
        },
        name: "CreateOrEdit",
        data() {
            return {
                permit: {},
                permitTypes:[],
                isEdit:false,
                title:''
            }
        },
         created(){
          
            this.isEdit = (Id === undefined) ? true : false;
           
           if (Id !== undefined) {
              this.isEdit = true;
              this.title ='Edit Permit'
               this.getPermitById(Id);
           }
           else{
               this.isEdit=false;
              this.title ='Create Permit';
           } 
  
        },
        methods:{
            getPermitById(Id){
                
                 axios.get(`${urlBase}/GetPermitsById/${Id}`).then((response) => {
                        
                        let result = response.data;

                         if(result.Success){
                          
                            this.permit = result.Data;
                         }
                         else{
                            alert(result.Message);
                         }
                        
                    }).catch(function(error){
                       
                       console.log(error);
               });
            },
            getPermitTypes(){
                   
                 axios.get(`${urlBase}/GetPermitTypes`).then((response) => {
                        
                        let result = response.data;

                         if(result.Success){
                           
                            this.permitTypes = [];
                            this.permitTypes=result.Data;
                         }
                         else{
                            alert(result.Message);
                         }
                        
                    }).catch(function(error){
                       
                       console.log(error);
               });
            },
            SavePermit(){
                
                let endPoint = this.isEdit ? 'EditPermit' : 'SavePermit';

                let urlApi = `${urlBase}/${endPoint}/`;

                var params = {
                    Id: this.permit.Id,
                    EmployeeName: this.permit.EmployeeName,
                    EmployeeLastName: this.permit.EmployeeLastName,
                    PermitTypeId: this.permit.PermitTypeId,
                    PermitDateDesc:this.permit.PermitDateDesc
                
                }

                axios.post(urlApi,params).then((response) => {
                
                let result = response.data;

                if (result.Success) {
                    
                    alert(result.Message);
                    
                    this.getPermits();
                }
                else{
                      alert(result.Message);
                }
            }).catch(function(error){
                    console.log(error);
                });
                  
            },
            Cancel(){
                this.permit = {};
                this.$router.push({name:'PermitList'});
            }
        }, 
        mounted() {
            this.getPermitTypes();
        }
    }
</script>

<style scoped>

</style>