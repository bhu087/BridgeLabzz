function activeLogin() {
	$(document).ready(function () {
		$("#LoginDiv").show();
	});
	deActiveParagraph();
}
function deActiveLogin() {
	$(document).ready(function () {
		$("#LoginDiv").hide();
	});
}
function activeEmployeeManagement() {
	$(document).ready(function () {
		$("#EmployeeManagement").show();
	});
	deActiveParagraph();
}
function deActiveEmployeeManagement() {
	$(document).ready(function () {
		$("#EmployeeManagement").hide();
	});
}
function activeParagraph() {
	$(document).ready(function () {
		$("#paragraph").show();
	});
	deActiveEmployeeManagement();
	deActiveLogin();
}
function deActiveParagraph() {
	$(document).ready(function () {
		$("#paragraph").hide();
	});
}
function LoginAction() {
	$(document).ready(function () {
		var formData = new FormData;
		formData.append('name', $("#LoginName").val());
		formData.append('userId', $("#LoginPassword").val());
		formData.append('mobile', $("#LoginMobile").val());
		$.ajax({
			url: "api/login",
			type: 'POST',
			cache: false,
			contentType: false,
			processData: false,
			data: formData,
			success: function (response) {
				// Replace the div's content with the page method's return.
				alert(response);
			},
			error: function (response) {
				console.log(response);
				alert(response)
			}
		});
	});
}
function RegisterAction() {
	$(document).ready(function () {
		//var formData = new FormData;
		//formData.append('Id',$("#RegisterId").val());
		//formData.append('name',$("#RegisterName").val());
		//formData.append('mobile',$("#RegisterMobile").val());
		//formData.append('salary',$("#registerSalary").val());
		//formData.append('city', $("#RegisterCity").val());
		//console.log(formData);
		//var data = {
		//	Id:document.getElementById("RegisterId").value,
		//	name:document.getElementById("RegisterName").value,
		//	mobile:document.getElementById("RegisterMobile").value,
		//	salary: document.getElementById("RegisterSalary").value,
		//	city:document.getElementById("RegisterCity").value
		//}
		//console.log(data);
		//$.ajax({
		//	url: "api/add",
		//	type: 'POST',
		//	cache: false,
		//	contentType: 'application/json; charset=utf-8',
		//	processData: true,
		//	async: true,
		//	data: JSON.stringify(data),
		//	success: function (response) {
		//		// Replace the div's content with the page method's return.
		//		alert(response);
		//	}
		var formData = new FormData;
		formData.append("name", $("#RegisterName").val());
		formData.append("mobile", $("#RegisterMobile").val());
		formData.append("salary", $("#RegisterSalary").val());
		formData.append("city", $("#RegisterCity").val());

		$.ajax({
			url: "api/add",
			type: 'POST',
			cache: false,
			contentType: false,
			processData: false,
			data: formData,
			success: function (response) {
				// Replace the div's content with the page method's return.
				alert(response);
			},
			error: function (response) {
				alert(response);
			}
		});
	});
}